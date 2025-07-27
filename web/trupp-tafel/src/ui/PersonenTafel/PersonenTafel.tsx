import './PersonenTafel.css';
import type {Person} from "../../lib/Person.ts";
import {CSS} from "@dnd-kit/utilities";
import {useSortable} from "@dnd-kit/sortable";

export const PersonenTafel = ({id, person}:{id:number, person:Person}) => {
    const {attributes, listeners, setNodeRef, transform, transition} = useSortable({id});

    const style = {
        transition: transition,
        transform: CSS.Translate.toString(transform)
    }

    return (
        <div ref={setNodeRef} style={style} className={`${person.getAusbildung()} personen-tafel`} {...listeners} {...attributes}>
            <div className={"personen-tafel-content"}>
                <h1>{person.getName()}</h1>
            </div>
        </div>
    );
}