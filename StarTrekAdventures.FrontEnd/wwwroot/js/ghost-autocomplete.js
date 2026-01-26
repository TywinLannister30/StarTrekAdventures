(() => {
    function onKeyDown(event) {
        if (event.key !== "Tab" || event.shiftKey) {
            return;
        }

        const target = event.target;
        if (!target || !target.classList || !target.classList.contains("ghost-autocomplete-input")) {
            return;
        }

        const remainder = target.dataset ? target.dataset.ghostRemainder : "";
        if (!remainder) {
            return;
        }

        event.preventDefault();
        target.value = `${target.value}${remainder}`;
        target.dispatchEvent(new Event("input", { bubbles: true }));
    }

    document.addEventListener("keydown", onKeyDown, true);
})();
