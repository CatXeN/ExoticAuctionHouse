import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'fuelPipeTranslator'
})
export class FuelPipeTranslatorPipe implements PipeTransform {

  transform(value: number): string {
    let fuelType: string[] = ['Petrol', 'Diesel', 'Hybrid', 'Electric', 'Other'];
    return fuelType[value - 1];
  }

}
