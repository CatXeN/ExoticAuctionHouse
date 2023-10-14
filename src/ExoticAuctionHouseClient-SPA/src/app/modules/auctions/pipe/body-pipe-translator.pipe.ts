import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'bodyPipeTranslator'
})
export class BodyPipeTranslatorPipe implements PipeTransform {

  transform(value: number): string {
    console.log(value);
    let bodyType: string[] = ['Sedan', 'Combi', 'Suv', 'Coupe', 'Hatchback', 'Cabrio', 'Pickup', 'Van', 'Minivan', 'Bus', 'Other'];
    return bodyType[value - 1];
  }
}
