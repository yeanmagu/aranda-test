import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  ValidarInicio() {
    const data = localStorage.getItem('UserData');
    if (data == null) {
       return true;
    }else
       return false;
      
  }
}
