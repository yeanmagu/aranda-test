import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Roles } from 'src/models/Roles';
import { Router } from '@angular/router';
import { Users } from 'src/models/Users';
import { LoginData } from 'src/models/logindata';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  public listUsers: LoginData[];
  public user = new Users();
  public edit = false;
  
  public loading = false;
  constructor(private router: Router,private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  
  }


  Guardar(){
    this.http.post<any>(this.baseUrl + 'api/users/login',this.user).subscribe(result => {
      this.listUsers = result.result;
      localStorage.setItem('UserData', JSON.stringify(result.result));    
      location.reload();
    }, error => console.error(error));
  }
}


