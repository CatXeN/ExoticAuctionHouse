import { Component } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {UserRegistration} from "../../../../shared/models/user-registration.model";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register-container',
  templateUrl: './register-container.component.html',
  styleUrls: ['./register-container.component.scss']
})
export class RegisterContainerComponent {
  registerForm = this.fb.group({
    username: ['', Validators.required],
    email: ['', Validators.email],
    password: ['', Validators.required],
    agreeTerm: [false, Validators.requiredTrue]
  });

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {}

  public register(): void {
    if (this.registerForm.valid) {
      const user: UserRegistration = {
        username: this.registerForm.controls.username.value,
        email: this.registerForm.controls.email.value,
        password: this.registerForm.controls.password.value
      }

      this.authService.register(user).subscribe(result => {
        if (result) {
          this.router.navigate(['']);
        }
      })
    }
  }
}
