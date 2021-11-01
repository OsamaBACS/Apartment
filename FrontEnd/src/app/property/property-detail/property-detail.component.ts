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
  public mainPhotoUrl: string = '';
  property = new Property();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService
  ) {}

  ngOnInit(): void {
    // this.propertyId = Number(this.route.snapshot.params['id']);
    this.propertyId = +this.route.snapshot.params['id'];

    // this.route.data.subscribe(
    //   (data: Property) => 
    //   {
    //     this.property = data['prp'];
    //     console.log(this.property.photos);
    //   }
    // );

    this.property.age = this.housingService.getPropertyAge(
      this.property.estPossessionOn!
    );

    this.route.params.subscribe((params) => {
      this.propertyId = +params['id'];
      this.housingService.getProperty(this.propertyId).subscribe(
        (data: any) => {
          this.property = data;
          console.log(this.property.photos);
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

    this.galleryImages = this.getPropertyPhoto();
  }

  getPropertyPhoto(): NgxGalleryImage[]
  {
    const photoUrls : NgxGalleryImage[] = [];
    for(let photo of this.property.photos)
    {
      if(photo.isBrimary) this.mainPhotoUrl = photo.imageUrl;
      photoUrls.push(
        {
          small: photo.imageUrl,
          medium: photo.imageUrl,
          big: photo.imageUrl,
        }
      );
    }
    return photoUrls;
  }
}
