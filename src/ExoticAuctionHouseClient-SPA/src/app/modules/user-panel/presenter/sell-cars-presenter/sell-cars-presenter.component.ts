import {Component, OnInit} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {DashboardService} from "../../../dashboard/services/dashboard.service";
import {CarAttribute} from "../../../../shared/models/cat-attribute.model";
import {GroupedAttributes} from "../../../../shared/models/grouped-attribute.model";
import {UserService} from "../../services/user.service";
import {Attribute} from "../../../../shared/models/attribute.model";
import {AuctionService} from "../../../auctions/services/auction.service";
import {Car } from "../../../../shared/models/car.model";
import {Auction} from "../../../../shared/models/auction.model";
import {SellCar} from "../../../../shared/models/sell-car.model";
import {AddCarAttribute} from "../../../../shared/models/add-car-attributes.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sell-cars-presenter',
  templateUrl: './sell-cars-presenter.component.html',
  styleUrls: ['./sell-cars-presenter.component.scss']
})
export class SellCarsPresenterComponent implements OnInit {
  public fuelTypes: string[] = [];
  public bodyTypes: string[] = [];
  groupedAttributes: GroupedAttributes[] = [];
  public attributes: CarAttribute[] = [];
  private fileToUpload: FileList | null = null;

  constructor(private fb: FormBuilder, private dashboardService: DashboardService, private userService: UserService, private router: Router) {
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

  auctionForm = this.fb.group({
    id: [''],
    amountStarting: [0, Validators.required],
    currentPrice: [0, Validators.required],
    biddingBegins: ['', Validators.required],
    createdAt: ['', Validators.required],
    carId: ['', Validators.required],
    location: ['', Validators.required],
    isEnd: [false, Validators.required]
  });

  public ngOnInit(): void {
    this.dashboardService.getPageData().subscribe(result => {
      this.fuelTypes = result.fuelTypes;
      this.bodyTypes = result.bodyTypes;
    });

    this.userService.getAttributes().subscribe((data) => {
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

  compareObjects(o1: Attribute, o2: CarAttribute): boolean {
    return o1.id == o2.attributeId;
  }

  public handleFileInput(data: any) : void {
    let files: FileList = data.files;
    if (files === null || files.length === 0) return;
    this.fileToUpload = files;
  }

  public sell(): void {
    let car: Car = new Car();
    let auction: Auction = new Auction();
    Object.assign(car, this.carForm.value);
    Object.assign(auction, this.auctionForm.value);

    let carAttributes: AddCarAttribute  = {
      attributes: this.attributes.map((attribute: CarAttribute) => attribute.id),
      carId: '00000000-0000-0000-0000-000000000000'
    }

    auction.carId = '00000000-0000-0000-0000-000000000000';
    auction.createdAt = new Date();
    auction.isEnd = false;
    car.isSold = false;

    let sellCar: SellCar = {
      car: car,
      auction: auction,
      addCarAttributeInformation: carAttributes
    };

    this.userService.sellCar(sellCar).subscribe(commonInformation => {
      if (this.fileToUpload === null)  {
        this.router.navigate(['/panel/auctions/' + commonInformation.auctionId]);
        return;
      }

      const formData: any = new FormData();
      for (let i = 0; i < this.fileToUpload.length; i++) {
        const fileToUpload =  this.fileToUpload.item(i);

        if (fileToUpload === null) {
          continue;
        }

        formData.append(`files`, fileToUpload, fileToUpload.name);
      }

      this.userService.updateImage(formData, commonInformation.carId).subscribe(res => {
        this.router.navigate(['/panel/auctions/' + commonInformation.auctionId])
      })
    })
  }
}
