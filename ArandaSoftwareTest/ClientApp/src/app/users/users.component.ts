import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Users } from 'src/models/Users';
import { Roles } from 'src/models/Roles';
import { Permisos } from 'src/models/Permisos';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent {
  public listUsers: Users[];
  public listRoles: Roles[];
  public user = new Users();
  public permisos = new Permisos();
  public edit = false;
  public mensaje = '';
  public alert = '';
  public term = '';
  public loading = false;
  public fechaNac = '';
  private password = '';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    const data = localStorage.getItem('UserData');
    if (data != null) {
      this.permisos = JSON.parse(data).permisos;
      console.log(this.permisos.ver);
    }
    if (this.permisos.ver) {
      this.fillUsers();
      this.fillRoles();
    }

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.

  }
  delete(item) {
    if (confirm("Esta seguro que quiere eliminar el usuario ?")) {
      this.http.delete<any>(this.baseUrl + 'api/users/delete/' + item.id,).subscribe(result => {
        this.mensaje = result.Message;
        this.alert = 'aler-success';
        this.fillUsers();
      }, error => {
        this.mensaje = 'Opps ha ocurrido un error!';
        this.alert = 'aler-danger';
        console.error(error)
      });
    }
  }
  select(item) {
    this.edit = !this.edit;
    this.user = item;
    this.password = item.password;
    this.user.password = '';
    this.fechaNac = new Date(this.user.fechaNacimiento).toLocaleDateString();
  }
  fillUsers() {
    this.http.get<any>(this.baseUrl + 'api/users').subscribe(result => {
      this.listUsers = result.result;
    }, error => console.error(error));
  }
  fillRoles() {
    this.http.get<any>(this.baseUrl + 'api/roles').subscribe(result => {
      this.listRoles = result.result;
    }, error => console.error(error));
  }

  Nuevo() {
    this.user = new Users();
    this.edit = !this.edit;

  }
  Cancelar() {
    this.user = new Users();
    this.edit = !this.edit;
  }
  Filter(textFilter) {
    if (textFilter){
      this.http.get<any>(this.baseUrl + `api/users/get/${textFilter}`).subscribe(result => {
        this.listUsers = result.result;
      }, error => console.error(error));
    }
    
  }
  Guardar() {
    this.user.rolesId = +this.user.rolesId;
    let userTem = this.user;

    // this.user.fechaNacimiento = new Date(this.fechaNac);
    if (this.user.id > 0) {
      this.user = new Users();
      this.user.id = userTem.id;
      this.user.apellidos = userTem.apellidos;
      this.user.direccion = userTem.direccion;
      this.user.email = userTem.email;
      this.user.fechaNacimiento = userTem.fechaNacimiento;
      this.user.nombres = userTem.nombres;
      this.user.rolesId = userTem.rolesId;
      this.user.username = userTem.username;
      this.user.telefono = userTem.telefono;
      this.user.password = userTem.password;
      this.http.put<any>(this.baseUrl + 'api/users', this.user).subscribe(result => {
        this.listUsers = result.result;
        this.mensaje = result.Message;
        this.alert = 'aler-success';
        this.edit = !this.edit;
        this.fillUsers();
      }, error => {
        this.mensaje = 'Opps ha ocurrido un error!';
        this.alert = 'aler-danger';
        console.error(error)
      });
    } else {
      this.http.post<any>(this.baseUrl + 'api/users', this.user).subscribe(result => {
        this.listUsers = result.result;
        this.mensaje = result.Message;
        this.alert = 'aler-success';
        this.edit = !this.edit;
        this.fillUsers();
      }, error => {
        this.mensaje = 'Opps ha ocurrido un error!';
        this.alert = 'aler-danger';
        console.error(error)
      });
    }
  }
}
