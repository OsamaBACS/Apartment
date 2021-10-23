import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user';
import { UserServiceService } from 'src/app/services/user-service.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css'],
})
export class UserRegisterComponent implements OnInit {
  registrationForm!: FormGroup;
  user!: User;
  userSubmitted!: boolean;

  constructor(private fb: FormBuilder, 
    private authService: AuthService, 
    private alertifyService: AlertifyService) {}

  ngOnInit(): void {
    // this.registrationForm = new FormGroup({
    //   userName: new FormControl(null, Validators.required),
    //   email: new FormControl(null, [Validators.required, Validators.email]),
    //   password: new FormControl(null, [
    //     Validators.required,
    //     Validators.minLength(8),
    //   ]),
    //   confirmPassword: new FormControl(null, [Validators.required]),
    //   mobile: new FormControl(null, [
    //     Validators.required,
    //     Validators.maxLength(10),
    //   ]),
    // }, this.passwordMatchingValidator);
    this.createRegistrationForm();
  }

  createRegistrationForm(){
    this.registrationForm = this.fb.group({
      userName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(8)]],
      confirmPassword: [null, Validators.required],
      mobile: [null, [Validators.required, Validators.maxLength(10)]]
    }, {
      Validators: this.passwordMatchingValidator
    })
  }

  passwordMatchingValidator(fc: AbstractControl): ValidationErrors | null {
    return fc.get('password')?.value === fc.get('confirmPassword')?.value ? null : {notMatched: true};
  }

  // ------------------------------------
  // Getter methods for all form controls
  // ------------------------------------
  get userName (){
    return this.registrationForm.get('userName') as FormControl;
  }
  get email (){
    return this.registrationForm.get('email') as FormControl;
  }
  get password (){
    return this.registrationForm.get('password') as FormControl;
  }
  get confirmPassword (){
    return this.registrationForm.get('confirmPassword') as FormControl;
  }
  get mobile (){
    return this.registrationForm.get('mobile') as FormControl;
  }
  // -----------------------------------

  onSubmit() {
    console.log(this.registrationForm.value);
    this.userSubmitted = true;
      if(this.registrationForm.valid){
      // this.user = Object.assign(this.user, this.registrationForm.value);
      this.authService.registerUser(this.userData()).subscribe(
        () => {
          this.registrationForm.reset();
          this.userSubmitted = false;
          this.alertifyService.success(
            'Congrats, you are successfully registered!'
          );
        }
      ); 
    }
  }

  userData(): User{
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile: this.mobile.value,
    }
  }
}
