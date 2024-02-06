import {Component, Input, OnInit} from '@angular/core';
import {Car} from "../../../../shared/models/car.model";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import { formatDate } from '@angular/common';
import {CarsService} from "../../services/cars.service";
import {SnackbarService} from "../../../../shared/services/snackbar.service";
import {Route, Router} from "@angular/router";

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.scss']
})
export class CarDetailsComponent implements OnInit {
  public car: Car | null = null;

  public fuelTypes: string[] = [];
  public bodyTypes: string[] = [];

  @Input() set _car(value: Car | null) {
    if (value) {
      this.car = value;

      this.carForm.patchValue({
        id: this.car.id,
        brand: this.car.brand,
        model: this.car.model,
        generation: this.car.generation,
        fuelType: this.car.fuelType,
        capacity: this.car.capacity,
        horsepower: this.car.horsepower,
        mileage: this.car.mileage,
        bodyType: this.car.bodyType,
        productionDate: this.car.productionDate.toString(),
        isSold: this.car.isSold
      });
    }
  }

  carForm = this.fb.group({
    id: [''],
    brand: ['', Validators.required],
    model: ['', Validators.required],
    generation: ['', Validators.required],
    fuelType: [0, Validators.required],
    capacity: [0, Validators.required],
    horsepower: [0, Validators.required],
    mileage: [0, Validators.required],
    bodyType: [0, Validators.required],
    productionDate: ['', Validators.required],
    isSold: [false, Validators.required]
  });

  constructor(private fb: FormBuilder, private carService: CarsService, private snackbarService: SnackbarService, private router: Router) {}

  ngOnInit(): void {
    this.carService.getPageData().subscribe(result => {
      this.fuelTypes = result.fuelTypes;
      this.bodyTypes = result.bodyTypes;
    });
  }

  saveChanges(): void {
    let car: Car = {
      id: this.carForm.get('id')?.value!,
      brand: this.carForm.get('brand')?.value!,
      model: this.carForm.get('model')?.value!,
      generation: this.carForm.get('generation')?.value!,
      fuelType: this.carForm.get('fuelType')?.value!,
      capacity: this.carForm.get('capacity')?.value!,
      horsepower: this.carForm.get('horsepower')?.value!,
      mileage: this.carForm.get('mileage')?.value!,
      bodyType: this.carForm.get('bodyType')?.value!,
      productionDate: new Date(this.carForm.get('productionDate')?.value!),
      isSold: this.carForm.get('isSold')?.value!,
      ownerId: localStorage.getItem('id')!
    };

    if (car.id === '') {
      this.carService.addCar(car).subscribe(result => {
        this.snackbarService.alert(result, 'Ok');
        this.router.navigate(['/panel/cars'])
      });
    } else {
      this.carService.editCar(car).subscribe(result => {
        this.snackbarService.alert('Car added successfully', 'Ok');
        this.router.navigate(['/panel/cars'])
      });
    }
  }
}
