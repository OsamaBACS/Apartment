import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import { NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { NgxGalleryImage } from '@kolkov/ngx-gallery';
import { NgxGalleryAnimation } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css'],
})
export class PropertyDetailComponent implements OnInit {
  
  galleryOptions!: NgxGalleryOptions[];
  galleryImages!: NgxGalleryImage[];

  public propertyId!: number;
  property = new Property();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService
  ) {}

  ngOnInit(): void {
    // this.propertyId = Number(this.route.snapshot.params['id']);
    this.propertyId = +this.route.snapshot.params['id'];
    this.property.age = this.housingService.getPropertyAge(this.property.estPossessionOn!);

    // this.route.data.subscribe(
    //   (data: any) => {
    //     this.property = data['prp'];
    //   }
    // );

    this.route.params.subscribe((params) => {
      this.propertyId = +params['id'];
      this.housingService.getProperty(this.propertyId).subscribe(
        (data: any) => {
          this.property = data!;
        },
        (error) => this.router.navigate(['/'])
      );
    });
    ///////////////////
    this.galleryOptions = [
      {
        width: '100%',
        height: '400px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
      },
    ];

    this.galleryImages = [
      {
        small: 'assets/images/prop1.png',
        medium: 'assets/images/prop1.png',
        big: 'assets/images/prop1.png',
      },
      {
        small: 'assets/images/prop2.png',
        medium: 'assets/images/prop2.png',
        big: 'assets/images/prop2.png',
      },
      {
        small: 'assets/images/prop3.png',
        medium: 'assets/images/prop3.png',
        big: 'assets/images/prop3.png',
      },
      {
        small: 'assets/images/prop4.png',
        medium: 'assets/images/prop4.png',
        big: 'assets/images/prop4.png',
      },
      {
        small: 'assets/images/prop5.png',
        medium: 'assets/images/prop5.png',
        big: 'assets/images/prop5.png',
      },
    ];
  }
}
