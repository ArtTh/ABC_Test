import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Locations } from 'src/app/_models/locations';
import { LocationService } from 'src/app/_services/location.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  modalRef: BsModalRef;
  modalDet: BsModalRef;
  locations: Locations[];
  locationDetail: Locations;

  constructor(
    public locationService: LocationService,
    public router: Router,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.locationService.list().subscribe((response) => {
      this.locations = response;
    });
  }
  deleteData(template) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  viewData(details, id) {
    this.modalDet = this.modalService.show(details, { class: 'modal-sm' });
    this.locationService.detail(id).subscribe((response) => {
      this.locationDetail = response;
    });
  }
  confirm(id: number): void {
    this.locationService.delete(id).subscribe((response) => {
      window.location.reload();
    });
    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
}
