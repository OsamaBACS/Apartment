import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IPropertyBase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css'],
})
export class AddPropertyComponent implements OnInit {
  // @ViewChild('Form') addPropertyForm!: NgForm;
  @ViewChild('formTabs') formTabs!: TabsetComponent;

  addPropertyForm!: FormGroup;
  NextClicked!: boolean;

  // Will come from master
  propertyTypes: Array<string> = ['House', 'Apartment', 'Duplex'];
  furnishTypes: Array<string> = ['Fully', 'Semi', 'Unfurnished'];
  readyToMove: Array<string> = ['East', 'West', 'South', 'North'];

  propertyView: IPropertyBase = {
    Id: 0,
    SellRent: 1,
    Name: '',
    PType: '',
    FType: '',
    Price: 0,
    BHK: 0,
    BuiltArea: 0,
    City: '',
    RTM: 0,
  };

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.createAddPropertyForm();
  }

  createAddPropertyForm() {
    this.addPropertyForm = this.fb.group({
      BasicInfo: this.fb.group({
        SellRent: [null, Validators.required],
        PType: [null, Validators.required],
        Name: [null, Validators.required],
      }),
      PriceInfo: this.fb.group({
        Price: [null, Validators.required],
        BuiltArea: [null, Validators.required],
      }),
    });
  }

  //------------------------------
  // Getter Methods
  //------------------------------

  get BasicInfo() {
    return this.addPropertyForm.controls.BasicInfo as FormGroup;
  }

  get SellRent() {
    return this.BasicInfo.controls.SellRent as FormControl;
  }
  get PType() {
    return this.BasicInfo.controls.PType as FormControl;
  }
  get Name() {
    return this.BasicInfo.controls.Name as FormControl;
  }

  get PriceInfo() {
    return this.addPropertyForm.controls.PriceInfo as FormGroup;
  }

  get Price() {
    return this.PriceInfo.controls.Price as FormControl;
  }
  get BuiltArea() {
    return this.PriceInfo.controls.BuiltArea as FormControl;
  }

  //------------------------------

  onBack() {
    this.router.navigate(['/']);
  }

  onSubmit() {
    this.NextClicked = true;
    if(this.BasicInfo.invalid){
      this.formTabs.tabs[0].active = true;
      return;
    }
    if(this.PriceInfo.invalid){
      this.formTabs.tabs[1].active = true;
      return;
    }
    console.log(this.addPropertyForm);
    console.log('SellRent = ' + this.addPropertyForm.value.BasicInfo.SellRent);
  }

  selectTab(tabId: number, IsCurrentTabValid: boolean) {
    this.NextClicked = true;
    if (IsCurrentTabValid) {
      this.formTabs.tabs[tabId].active = true;
    }
  }
}
