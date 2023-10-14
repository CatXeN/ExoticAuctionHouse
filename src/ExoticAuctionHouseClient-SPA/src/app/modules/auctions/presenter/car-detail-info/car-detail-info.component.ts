import {Component, Input} from '@angular/core';
import {Car} from "../../../../shared/models/car.model";

@Component({
  selector: 'app-car-detail-info',
  templateUrl: './car-detail-info.component.html',
  styleUrls: ['./car-detail-info.component.scss']
})
export class CarDetailInfoComponent {
  public car: Car | null = null;

  @Input() set carModel(value: Car | undefined) {
    if (value) {
      this.car = value;
    }
  }
}