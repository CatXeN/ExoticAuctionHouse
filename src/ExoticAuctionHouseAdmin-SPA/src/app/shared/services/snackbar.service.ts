import { Injectable } from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  constructor(private _snackBar: MatSnackBar) { }

  alert(message: string, action: string): void {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
