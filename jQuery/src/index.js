$(() => {
  function createTabItemTemplate(contentID) {
    return $('<div>').attr('id', contentID).addClass('tab-item-content');
  }

  $('#tab-panel').dxTabPanel({
    deferRendering: false,
    items: [
      {
        title: 'Local Data',
        template: () => createTabItemTemplate('data-grid-local'),
      }, {
        title: 'Remote Data',
        template: () => createTabItemTemplate('data-grid-remote'),
      },
    ],
  });
});
