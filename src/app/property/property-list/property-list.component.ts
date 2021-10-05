import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css'],
})
export class PropertyListComponent implements OnInit {
  SellRent = 1;
  properties!: any;
  Today = new Date();
  City = '';
  searchCity: string = '';
  SortByParam: string = '';
  SortDirection = 'asc';

  constructor(
    private route: ActivatedRoute,
    private housingService: HousingService
  ) {}

  ngOnInit(): void {
    if (this.route.snapshot.url.toString()) {
      this.SellRent = 2; // means that we are in Rent
    }
    this.housingService.getAllProperties(this.SellRent).subscribe(
      (data) => {
        this.properties = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onCityFilter() {
    this.searchCity = this.City;
  }
  onCityFilterClear() {
    this.searchCity = '';
    this.City = '';
  }

  onSortDirection(){
    if (this.SortDirection === 'desc'){
      this.SortDirection = 'asc';
    } else {
      this.SortDirection = 'desc';
    }
  }
}
