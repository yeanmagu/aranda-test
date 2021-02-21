import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Users } from 'src/models/Users';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public user = new Users();
  /**
   *
   */
  constructor(private router: Router,) {
    
  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    const data = localStorage.getItem('UserData');
    if (data != null) {
      this.user = JSON.parse(data);
    }
  }
  collapse() {
    this.isExpanded = false;
  }
  logout(): void{
    localStorage.removeItem('UserData');  
    location.reload();
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
