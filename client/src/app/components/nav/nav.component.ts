import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  constructor(
    public accountService: AccountService,
    public router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  logout() {
    this.accountService.logout();
  }
}
