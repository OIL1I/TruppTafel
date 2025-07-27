import {Ausbildung} from "./Ausbildung";

export class Person{
    private name:string;
    private ausbildung:Ausbildung;

    public constructor(name:string = "Max Mustermann", ausbildung:Ausbildung = Ausbildung.ZF){
        this.name = name;
        this.ausbildung = ausbildung;
    }

    public getName(){
        return this.name;
    }
    public setName(name:string){
        this.name = name;
    }
    public getAusbildung(){
        return this.ausbildung;
    }
    public setAusbildung(ausbildung:Ausbildung){
        this.ausbildung = ausbildung;
    }
}