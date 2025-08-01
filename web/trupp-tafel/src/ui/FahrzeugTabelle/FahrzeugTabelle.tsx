import './FahrzeugTabelle.css';
import type {Fahrzeug} from "../../lib/Fahrzeug.ts";
import {useDroppable} from "@dnd-kit/core";
import {BesatzungsIndex} from "../../lib/Besatzungsliste.ts";

export function FahrzeugTabelle({id, fahrzeug}: { id: number, fahrzeug: Fahrzeug }) {
    return (
        <div className={"fahrzeug-tafel"}>
            <table>
                <thead>
                <tr>
                    <th colSpan={2}>{fahrzeug.getName()}</th>
                </tr>
                </thead>
                <tbody>
                {fahrzeug.getBesatzungsListe().map((besatzung, index) => {
                    const dropId = `drop-${id}-${index}`;
                    //@ts-ignore
                    const {setNodeRef} = useDroppable(dropId);

                    return (
                      <tr key={index}>
                          <td title={besatzung[BesatzungsIndex.VOLL]}>{besatzung[BesatzungsIndex.KURZ]}</td>
                          <td ref={setNodeRef}></td>
                      </tr>
                    );
                })}
                </tbody>
            </table>
        </div>
    );
}