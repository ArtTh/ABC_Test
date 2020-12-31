import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Locations } from 'src/app/_models/locations';
import { LocationService } from 'src/app/_services/location.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  locations: Locations[];

  constructor(public locationService: LocationService, public router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.locationService.list().subscribe((response) => {
      this.locations = response;
    });
  }
  deleteData(id: number) {}
}
