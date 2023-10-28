import {Component, Input} from '@angular/core';
import {Car} from "../../../../shared/models/car.model";
import {CarsService} from "../../services/cars.service";

@Component({
  selector: 'app-car-image',
  templateUrl: './car-image.component.html',
  styleUrls: ['./car-image.component.scss']
})
export class CarImageComponent {
  public car: Car | null = null;
  private fileToUpload: FileList | null = null;

  @Input() set _car(value: Car | null) {
    if (value) {
      this.car = value;
    }
  }

  constructor(private carService: CarsService) {

  }


  public handleFileInput(data: any) : void {
    let files: FileList = data.files;
    if (files === null || files.length === 0) return;

    console.log(files[0]);
    this.fileToUpload = files;
  }

  public uploadImages(): void {
    if (this.fileToUpload === null || this.car === null) return;

    const formData: any = new FormData();
    for (let i = 0; i < this.fileToUpload.length; i++) {
      const fileToUpload =  this.fileToUpload.item(i);

      if (fileToUpload === null) {
        continue;
      }

      formData.append(`files`, fileToUpload, fileToUpload.name);
    }

    this.carService.updateImage(formData, this.car.id).subscribe(res => {

    })
  }
}
