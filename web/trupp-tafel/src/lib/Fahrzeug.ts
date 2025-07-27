import {TruppListe, StaffelListe, GruppenListe} from "./Besatzungsliste";

export enum Besatzung {
    TRUPP = "Selbständiger Trupp",
    STAFFEL = "Staffel",
    GRUPPE = "Gruppe"
}

export class Fahrzeug {
    private name: string;
    private besatzung: Besatzung;
    private besatzungsListe: string[][];

    public constructor(name: string = "Fahrzeug", besatzung: Besatzung = Besatzung.TRUPP) {
        this.name = name;
        this.besatzung = besatzung;
        this.besatzungsListe = []; //Suppress error -> not initialized
        this.updateBesatzungsListe();
    }

    private updateBesatzungsListe():void {
        switch (this.besatzung) {
            case Besatzung.TRUPP:
                this.besatzungsListe = TruppListe;
                break;
            case Besatzung.STAFFEL:
                this.besatzungsListe = StaffelListe;
                break;
            case Besatzung.GRUPPE:
                this.besatzungsListe = GruppenListe;
                break;
        }
    }

    public getName(): string {
        return this.name;
    }

    public setName(name: string): void {
        this.name = name;
    }

    public getBesatzung(): Besatzung {
        return this.besatzung;
    }

    public setBesatzung(besatzung: Besatzung): void {
        this.besatzung = besatzung;
        this.updateBesatzungsListe();
    }

    public getBesatzungsListe(): string[][] {
        return this.besatzungsListe;
    }

}