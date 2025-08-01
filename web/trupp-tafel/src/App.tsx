import {useState} from 'react'
import './App.css'
import {Person} from "./lib/Person.ts";
import {Ausbildung} from "./lib/Ausbildung.ts";
import {DndContext, type DragEndEvent} from "@dnd-kit/core";
import {PersonenHalter} from "./ui/PersonenHalter/PersonenHalter.tsx";
import {arrayMove} from "@dnd-kit/sortable";
import {FahrzeugTabelle} from "./ui/FahrzeugTabelle/FahrzeugTabelle.jsx";
import {Besatzung, Fahrzeug} from "./lib/Fahrzeug.ts";

interface PersonenItem {
  id: number;
  person: Person;
}

function App() {
  const [personen, setPersonen] = useState<PersonenItem[]>([
    {id: 0, person: new Person("M. Müller", Ausbildung.TF)},
    {id: 1, person: new Person("P. Schulz", Ausbildung.GF)},
    {id: 2, person: new Person("H. Herneshalber", Ausbildung.ZF)}
  ]);

  const handleDragEnd = (event: DragEndEvent): void => {
    const {active, over} = event;
    
    if (!over || active.id === over.id) return;
    
    setPersonen(personen => {
      const currentPos = personen.findIndex(p => p.id === active.id);
      const newPos = personen.findIndex(p => p.id === over.id);
      
      if (currentPos === -1 || newPos === -1) return personen;
      
      return arrayMove(personen, currentPos, newPos);
    });
  };

  return (
    <DndContext onDragEnd={handleDragEnd}>
      <PersonenHalter personen={personen}/>
      <FahrzeugTabelle id={0} fahrzeug={new Fahrzeug("HLF20", Besatzung.TRUPP)}/>
    </DndContext>
  );
}

export default App