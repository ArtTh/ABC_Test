import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  currentUser$: Observable<User>;

  constructor(
    private accountService: AccountService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.currentUser$ = this.accountService.currentUser$;
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    this.accountService.login(this.loginForm.value).subscribe(
      (response) => {
        this.toastr.success('Successfully logged in');
        this.router.navigateByUrl('');
      },
      (error) => {
        this.toastr.error(error.error);
      }
    );
  }

  validate() {
    if (this.loginForm.valid) {
      this.login();
    } else {
      this.toastr.error('Please fill all required inputs');
    }
  }
}
