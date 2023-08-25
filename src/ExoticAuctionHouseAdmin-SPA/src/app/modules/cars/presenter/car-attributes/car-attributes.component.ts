import {Component, Input} from '@angular/core';
import {Car} from "../../../../shared/models/car.model";
import {CarsService} from "../../services/cars.service";
import {AddCarAttribute} from "../../../../shared/models/add-car-attributes.model";
import {AttributeService} from "../../../../shared/services/attribute.service";
import {Attribute} from "../../../../shared/models/attribute.model";
import {GroupedAttributes} from "../../../../shared/models/grouped-attributes.model";
import {MatSnackBar} from "@angular/material/snack-bar";
import {CarAttribute} from "../../../../shared/models/car-attribute.model";

@Component({
  selector: 'app-car-attributes',
  templateUrl: './car-attributes.component.html',
  styleUrls: ['./car-attributes.component.scss']
})
export class CarAttributesComponent {
  public carId: string = '';
  groupedAttributes: GroupedAttributes[] = [];
  public attributes: CarAttribute[] = [];

  @Input() set _car(value: Car | null) {
    if (value) {
      this.carId = value.id;

      this.carService.getAttributes(this.carId).subscribe((data) => {
        this.attributes = data;
      });

      this.attributeService.getAttributes().subscribe((data) => {
        let categories = [...new Set(data.map((attribute: any) => attribute.category))];

        categories.forEach((category: string) => {
          let groupedAttributes: GroupedAttributes = {
            category: category,
            attributes: Object.assign([], data.filter((res: any) => res.category === category))
          };

          this.groupedAttributes.push(groupedAttributes);
        });
      });
    }
  }

  constructor(private carService: CarsService, private  attributeService: AttributeService, private matSnackBar: MatSnackBar) { }

  saveChanges() {
    let carAttributes: AddCarAttribute  = {
      attributes: this.attributes.map((attribute: CarAttribute) => attribute.id),
      carId: this.carId
    }

    this.carService.addAttributes(carAttributes).subscribe((data) => {
      this.matSnackBar.open('Update successfully', 'Ok');
    });
  }

  compareObjects(o1: Attribute, o2: CarAttribute): boolean {
    return o1.id == o2.attributeId;
  }
}
