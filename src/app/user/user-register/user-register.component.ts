import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css'],
})
export class UserRegisterComponent implements OnInit {
  registrationForm!: FormGroup;
  user: any = {};

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.createRegistrationForm();
  }

  createRegistrationForm() {
    this.registrationForm = this.fb.group(
      {
        userName: new FormControl(null, Validators.required),
        email: new FormControl(null, [Validators.required, Validators.email]),
        password: new FormControl(null, [
          Validators.required,
          Validators.minLength(8),
        ]),
        confirmPassword: new FormControl(null, [Validators.required]),
        mobile: new FormControl(null, [
          Validators.required,
          Validators.maxLength(10),
        ]),
      },
      {
        Validator: this.passwordMatchingValidator(
          'password',
          'confirmPassword'
        ),
      }
    );
  }

  passwordMatchingValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      console.log(controlName + '--' + matchingControlName);
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (
        matchingControl.errors &&
        !matchingControl.errors.confirmedValidator
      ) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmedValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

  //----------------------------------------
  // Getters Methods for all formCOntrols //
  //----------------------------------------
  get UserName() {
    return this.registrationForm.get('userName') as FormControl;
  }
  get Email() {
    return this.registrationForm.get('email') as FormControl;
  }
  get Password() {
    return this.registrationForm.get('password') as FormControl;
  }
  get ConfirmPassword() {
    return this.registrationForm.get('confirmPassword') as FormControl;
  }
  get Mobile() {
    return this.registrationForm.get('mobile') as FormControl;
  }
  //----------------------------------------

  onSubmit() {
    this.user = Object.assign(this.user, this.registrationForm.value);
    this.addUser(this.user);
  }

  addUser(user: any) {
    localStorage.setItem('Users', JSON.stringify(user));
  }
}
