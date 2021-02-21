import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  public showLogin=true;
  /**
   *
   */
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.ValidarInicio();
  }

  ValidarInicio() {
    const data = localStorage.getItem('UserData');
    if (data == null) {
       this.showLogin=true;
    }else
      this.showLogin=false;
      
  }
}
