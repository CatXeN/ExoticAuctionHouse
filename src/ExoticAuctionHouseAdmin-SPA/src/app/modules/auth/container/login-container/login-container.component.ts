import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {Login} from "../../../../shared/models/login.model";
import {AuthService} from "../../services/auth.service";
import {JwtHelperService} from "@auth0/angular-jwt";
import {SnackbarService} from "../../../../shared/services/snackbar.service";

@Component({
  selector: 'app-login-container',
  templateUrl: './login-container.component.html',
  styleUrls: ['./login-container.component.scss'],
})
export class LoginContainerComponent {
  loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });
  jwtHelper = new JwtHelperService();

  constructor(private fb: FormBuilder, private router: Router, private authService: AuthService, private snackBar: SnackbarService) {}

  login(): void {

    if (this.loginForm.valid) {
      const data: Login = {
        username: this.loginForm.controls.username.value,
        password: this.loginForm.controls.password.value
      }

      this.authService.loginAsAdmin(data).subscribe({
        next: (token) => {
          localStorage.setItem('token', token);
          const decodedToken = this.jwtHelper.decodeToken(token);
          localStorage.setItem('id', decodedToken.nameid);
          localStorage.setItem('role', decodedToken.role);
          localStorage.setItem('name', decodedToken.unique_name);
          this.router.navigate(['panel/dashboard']);
        },
        error: (message) => {
          this.snackBar.alert(message.error, 'Ok')
          console.log(message.message)
        }
      });
    }
  }
}
