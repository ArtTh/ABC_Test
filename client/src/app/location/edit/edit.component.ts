import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LocationEdit } from 'src/app/_models/locationedit';
import { LocationService } from 'src/app/_services/location.service';
import { Location } from '../../_models/location';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
})
export class EditComponent implements OnInit {
  private locationData: Location = new Location();

  updateForm: FormGroup;
  cities: any = [];
  location: LocationEdit;
  id = parseInt(this.route.snapshot.paramMap.get('id'));

  constructor(
    private locationService: LocationService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getCities();
    this.getLocation();
  }

  initializeForm() {
    this.updateForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(20)]],
      address: ['', [Validators.required, Validators.maxLength(50)]],
      longitude: ['', Validators.required],
      latitude: ['', Validators.required],
      cityId: [0, Validators.required],
    });
  }

  update() {
    this.locationData = new Location(this.updateForm.value);
    console.log(this.updateForm.value);
    (this.locationData.latitude = parseFloat(
      this.updateForm.controls['latitude'].value
    )),
      (this.locationData.longitude = parseFloat(
        this.updateForm.controls['longitude'].value
      )),
      (this.locationData.cityId = parseInt(
        this.updateForm.controls['cityId'].value
      )),
      // console.log(this.locationData);
      this.locationService.edit(this.id, this.locationData).subscribe(
        (response) => {
          this.toastr.success('Successfully created!');
          this.router.navigateByUrl('/locations-list');
        },
        (error) => {
          this.toastr.error(error.error);
        }
      );
  }
  validate() {
    if (this.updateForm.valid) {
      this.update();
    } else {
      this.toastr.error('Please fill all required inputs');
    }
  }
  getLocation() {
    this.locationService.detail(this.id).subscribe((response) => {
      this.location = response;
      // console.log(this.location);
    });
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
