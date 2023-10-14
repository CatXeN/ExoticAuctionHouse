import {Component, Input} from '@angular/core';
import {AuctionService} from "../../services/auction.service";
import {TrasnlatedAttribute} from "../../../../shared/models/translated-attribute.model";

@Component({
  selector: 'app-car-detail-accessories',
  templateUrl: './car-detail-accessories.component.html',
  styleUrls: ['./car-detail-accessories.component.scss']
})
export class CarDetailAccessoriesComponent {
  private _carId: string = '';
  public categories: string[] = [];
  public attributes: TrasnlatedAttribute[] = [];

  @Input() set carId(value: string | undefined) {
    if (value) {
      this._carId = value;

      this.auctionService.getAttributes(this._carId).subscribe((data) => {
        this.attributes = data;

        this.categories = [...new Set(data.map((attribute: any) => attribute.category))];
        console.log(this.categories);
      });
    }
  }

  constructor(private auctionService: AuctionService) {}

  public getAttributes(category: string): TrasnlatedAttribute[] {
    return this.attributes.filter((attribute: TrasnlatedAttribute) => attribute.category === category);
  }
}
