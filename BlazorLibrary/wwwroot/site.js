function getContainerWidth(containerId) {
    const container = document.getElementById(containerId);
    return container ? container.offsetWidth : 0;
}