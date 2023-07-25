import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../services/dashboard.service';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import {MatAutocompleteSelectedEvent} from "@angular/material/autocomplete";

@Component({
  selector: 'app-dashboard-container',
  templateUrl: './dashboard-container.component.html',
  styleUrls: ['./dashboard-container.component.scss']
})
export class DashboardContainerComponent implements OnInit {
  filterForm = this.fb.group({
    brand: ['', Validators.required],
    model: ['', Validators.required],
    fuelType: ['', Validators.required],
    bodyType: ['', Validators.required]
  });

  private _brands: string[] = [];
  private _models: string[] = [];
  private _fuelTypes: string[] = [];
  private _bodyTypes: string[] = [];

  filteredBrands: Observable<string[]> = new Observable<string[]>();
  filteredModels: Observable<string[]> = new Observable<string[]>();
  filteredFuelTypes: Observable<string[]> = new Observable<string[]>();
  filteredBodyTypes: Observable<string[]> = new Observable<string[]>();

  constructor(private fb: FormBuilder, private dashboardService: DashboardService) {}

  ngOnInit() {
    this.dashboardService.getPageData().subscribe(result => {
      this._brands = result.brand;
      this._fuelTypes = result.fuelTypes;
      this._bodyTypes = result.bodyTypes;

      this.filteredBrands = this.filterForm.controls.brand.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '', this._brands)),
      );

      this.filteredFuelTypes = this.filterForm.controls.fuelType.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '', this._fuelTypes)),
      );

      this.filteredBodyTypes = this.filterForm.controls.bodyType.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '', this._bodyTypes)),
      );
    });
  }

  private _filter(value: string, collection: string[]): string[] {
    const filterValue = value.toLowerCase();
    return collection.filter(x => x.toLowerCase().includes(filterValue));
  }

  public getModelsByBrand(brand: MatAutocompleteSelectedEvent) {
    this.filterForm.controls.model.patchValue('')

    this.dashboardService.getModelsByBrand(brand.option.value).subscribe(result => {
      this._models = result;

      this.filteredModels = this.filterForm.controls.model.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '', this._models))
      )
    })
  }
}
