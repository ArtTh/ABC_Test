import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
    private accountService: AccountService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      displayName: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(
      (response) => {
        this.toastr.success('Successfully registered!');
        this.router.navigateByUrl('');
      },
      (error) => {
        this.toastr.error(error.error);
      }
    );
  }

  validate() {
    if (this.registerForm.valid) {
      this.register();
    } else {
      this.toastr.error('Please fill all required inputs');
    }
  }
}
