export function enableDrag(el, payloadJson){
    if(!el) return;
    console.log("Setting draggable:\n" + payloadJson);
    el.setAttribute('draggable', 'true');
    el.addEventListener('dragstart', (e) => {
        e.dataTransfer.setData('application/json', payloadJson);
        e.dataTransfer.effectAllowed = 'move';
    }, {passive: true});
}

export function enableDrop(el, dotNetRef, roleKey) {
    if(!el) return;
    
    const overClass = 'over';
    
    el.addEventListener('dragover', (e) => {
        e.preventDefault();
        e.dataTransfer.dropEffect = 'move';
        el.classList.add(overClass);
    });
    
    el.addEventListener('dragleave', (e) => {
        el.classList.remove(overClass);
    });

    el.addEventListener('drop', (e) => {
        e.preventDefault();
        el.classList.remove(overClass);

        const json = e.dataTransfer.getData('application/json') || e.dataTransfer.getData('text/plain');
        if (json) {
            // .NET-Instanzmethode aufrufen und Daten + Zielrolle übergeben
            dotNetRef.invokeMethodAsync('OnJsDrop', json, roleKey);
        }
    });

}