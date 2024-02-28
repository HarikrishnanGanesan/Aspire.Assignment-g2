import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtToken } from 'src/app/interface/JwtToken';
import { login } from 'src/app/interface/login';
import { jwtDecode } from 'jwt-decode';
import { ToastrService } from 'ngx-toastr';
import { User } from '../interface/User';
import { AppService } from '../services/app.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  user = new User();

  constructor(private authService: AppService,private toastr: ToastrService,private router:Router) {}

  register(user: User) {
    this.authService.register(user).subscribe();
    this.toastr.success('Registration successful', 'Success');
  }

  login(user: User) {
    this.authService.login(user).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
      this.toastr.success('Login successful', 'Success');
      this.router.navigate(['/UserProfile']);
    }, () => {
      this.toastr.error('Invalid credentials', 'Error');
    });
  }

  getme() {
    this.authService.getMe().subscribe((name: string) => {
      console.log(name);
      this.toastr.success('User successful', 'Success');
    });
  }
  
  // constructor(private router: Router, private http: HttpClient, private fb: FormBuilder,private toastrService: ToastrService) {} 

  // InvalidLogin: boolean = false;
  // loginForm!: FormGroup; 


  // ngOnInit(): void {
  //   this.loginForm = this.fb.group({
  //     email: ['', [Validators.required, Validators.email]], 
  //     password: ['', Validators.required] 
  //   });
  // }

  // login() {
  //   if (this.loginForm.valid) {
      
  //     const credentials: login = this.loginForm.value; 

  //     this.http.post<JwtToken>("https://localhost:5001/api/Authentication/login", credentials, {
  //       headers: new HttpHeaders({"Content-Type": "application/json"})
  //     })
  //     .subscribe({
  //       next: (response: JwtToken) => {
  //         const token = response.Token;
  //         const refreshToken = response.refreshToken;
  //         localStorage.setItem("jwt", token);
  //         localStorage.setItem("refreshToken", refreshToken);
  //         this.InvalidLogin = false;
  //         this.router.navigate(['/UserProfile']);
  //         console.log("Token:", token);
  //         this.toastrService.success('Login successful', 'Success');
  //         const decodedToken = jwtDecode(token);
  //         console.log(decodedToken);
  //       },
      
  //       error: (err: HttpErrorResponse) => {
  //         this.InvalidLogin = true;
  //         this.toastrService.error('Login Unsuccessful', 'Error');
  //       }
  //     });
  //   }
  // }
}
