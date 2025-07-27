import "./PersonenHalter.css"
import type {Person} from "../../lib/Person.ts";
import {PersonenTafel} from "../PersonenTafel/PersonenTafel.tsx";
import {SortableContext} from "@dnd-kit/sortable";

export function PersonenHalter({personen}: { personen: { id: number, person: Person }[] }) {
    return (
        <SortableContext items={personen}>
            <div className={"personen-halter"}>
                {personen.map(person => (
                    <PersonenTafel id={person.id} person={person.person} key={person.id}/>
                ))}
            </div>
        </SortableContext>
    );
}