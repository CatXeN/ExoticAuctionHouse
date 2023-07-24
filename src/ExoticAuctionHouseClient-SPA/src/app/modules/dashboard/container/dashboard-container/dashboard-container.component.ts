import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../services/dashboard.service';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-dashboard-container',
  templateUrl: './dashboard-container.component.html',
  styleUrls: ['./dashboard-container.component.scss']
})
export class DashboardContainerComponent implements OnInit {
  filterForm = this.fb.group({
    brand: ['', Validators.required],
    model: ['', Validators.required],
  });

  private _brands: string[] = [];
  private _models: string[] = [];

  filteredBrands: Observable<string[]> = new Observable<string[]>();

  constructor(private fb: FormBuilder, private dashboardService: DashboardService) {}

  ngOnInit() {
    this.dashboardService.getPageData().subscribe(result => {
      this._brands = result.brand;
      this._models = result.model;

      this.filteredBrands = this.filterForm.controls.brand.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '', this._brands)),
      );
    });
  }

  private _filter(value: string, collection: string[]): string[] {
    const filterValue = value.toLowerCase();
    return collection.filter(x => x.toLowerCase().includes(filterValue));
  }
}
