export function enableDrop(el, dotNetRef, roleKey) {
    if(!el) {
        console.error('enableDrop: Element ist null oder undefined');
        return;
    }
    
    // Prüfen ob bereits Event-Listener existieren
    if (el.dataset.dropEnabled) {
        console.log('Drop bereits aktiviert für Element:', roleKey);
        return;
    }
    
    const overClass = 'over';
    
    const dragOverHandler = (e) => {
        e.preventDefault();
        e.dataTransfer.dropEffect = 'move';
        el.classList.add(overClass);
    };
    
    const dragLeaveHandler = (e) => {
        el.classList.remove(overClass);
    };

    const dropHandler = (e) => {
        e.preventDefault();
        el.classList.remove(overClass);

        const json = e.dataTransfer.getData('application/json') || e.dataTransfer.getData('text/plain');
        if (json) {
            try {
                dotNetRef.invokeMethodAsync('OnJsDrop', json, roleKey)
                    .catch(error => {
                        console.error('Fehler beim Aufrufen von OnJsDrop:', error);
                    });
            } catch (error) {
                console.error('Fehler beim Verarbeiten des Drops:', error);
            }
        }
    };
    
    el.addEventListener('dragover', dragOverHandler);
    el.addEventListener('dragleave', dragLeaveHandler);
    el.addEventListener('drop', dropHandler);
    
    // Markierung dass Drop aktiviert ist
    el.dataset.dropEnabled = 'true';
    
    console.log('Drop aktiviert für:', roleKey);
}

export function enableDrag(el, payloadJson){
    if(!el) {
        console.error('enableDrag: Element ist null oder undefined');
        return;
    }
    
    console.log("Setting draggable:\n" + payloadJson);
    el.setAttribute('draggable', 'true');
    
    const dragStartHandler = (e) => {
        try {
            e.dataTransfer.setData('application/json', payloadJson);
            e.dataTransfer.effectAllowed = 'move';
        } catch (error) {
            console.error('Fehler beim Setzen der Drag-Daten:', error);
        }
    };
    
    el.addEventListener('dragstart', dragStartHandler, {passive: true});
}