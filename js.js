geocoding();

function geocoding(){
    fetch("https://api.opencagedata.com/geocode/v1/json?q=Rua Amazonas+Blumenau+Brasil&key=de8ec31691d84fada09018809123c939&pretty=1")
    .then(data => data.json())
    .then(item => console.log(item))
}