import {Component, Input} from '@angular/core';
import {Car} from "../../../../shared/models/car.model";
import {CarsService} from "../../services/cars.service";
import {AddCarAttribute} from "../../../../shared/models/add-car-attributes.model";

@Component({
  selector: 'app-car-attributes',
  templateUrl: './car-attributes.component.html',
  styleUrls: ['./car-attributes.component.scss']
})
export class CarAttributesComponent {
  public carId: string = '';
  @Input() set _car(value: Car | null) {
    if (value) {
      this.carId = value.id;

      this.carService.getAttributes(this.carId).subscribe((data) => {
        console.log(JSON.parse(data.attributes));
      });
    }
  }

  constructor(private carService: CarsService) { }

  saveChanges() {
    let carAttributes:AddCarAttribute  = {
      attributes: `{ "color": "red"}`,
      carId: this.carId
    }

    this.carService.addAttributes(carAttributes).subscribe((data) => {
      console.log(data);
    });
  }
}
