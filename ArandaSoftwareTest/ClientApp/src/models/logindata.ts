import { Permisos } from "./Permisos";
import { Roles } from "./Roles";
export class LoginData {
    id: number;
    username: string;
    nombresCompletos: Date;
    email:string;
    telefono: string;
    password:string;
    nombres:string;
    apellidos:string;
    rolesId :number;
    direccion:string;
    fechaNacimiento: Date;
    edad:number;
    rol: Roles;
    Permisos:Permisos;
  }