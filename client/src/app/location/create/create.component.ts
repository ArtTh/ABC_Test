import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LocationService } from 'src/app/_services/location.service';
import { Location } from '../../_models/location';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent implements OnInit {
  private locationData: Location = new Location();

  createForm: FormGroup;
  cities: any = [];

  constructor(
    private locationService: LocationService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getCities();
  }

  initializeForm() {
    this.createForm = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      longitude: ['', Validators.required],
      latitude: ['', Validators.required],
      cityId: [0, Validators.required],
    });
  }

  create() {
    this.locationData = new Location(this.createForm.value);
    (this.locationData.latitude = parseFloat(
      this.createForm.controls['latitude'].value
    )),
      (this.locationData.longitude = parseFloat(
        this.createForm.controls['longitude'].value
      )),
      (this.locationData.cityId = parseInt(
        this.createForm.controls['cityId'].value
      )),
      console.log(this.locationData);
    this.locationService.create(this.locationData).subscribe(
      (response) => {
        this.toastr.success('Successfully created!');
        this.router.navigateByUrl('/location');
      },
      (error) => {
        this.toastr.error(error.error);
      }
    );
  }

  validate() {
    if (this.createForm.valid) {
      this.create();
    } else {
      this.toastr.error('Please fill all required inputs');
    }
  }

  getCities() {
    this.locationService.getCities().subscribe(
      (data) => {
        this.cities = data;
      },
      (error) => {
        this.cities = null;
        this.toastr.error('Error occured while getting cities');
      }
    );
  }
}
