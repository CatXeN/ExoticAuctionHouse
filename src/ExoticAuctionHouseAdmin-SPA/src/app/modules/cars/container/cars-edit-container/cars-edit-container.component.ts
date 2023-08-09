import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {CarsService} from "../../services/cars.service";
import {Car} from "../../../../shared/models/car.model";

@Component({
  selector: 'app-cars-edit-container',
  templateUrl: './cars-edit-container.component.html',
  styleUrls: ['./cars-edit-container.component.scss']
})
export class CarsEditContainerComponent implements OnInit {
  public car: Car | null = null;

  constructor(private route: ActivatedRoute, private carService: CarsService) {
    this.route.params.subscribe(params => {
      if (params['id'] !== undefined) {
        this.carService.getCar(params['id']).subscribe(result => {
          this.car = result;
        });
      }
    });
  }

  ngOnInit(): void {
  }
}
