function gerarQRCode() {
    const random = (max, min) => Math.floor(Math.random() * (max - min) + min);
    var QRCode = 'https://chart.googleapis.com/chart?cht=qr&chs=400x400&chld=H&chl=';
    var key = random(100000, 999999);
    var alimentarQRCode = QRCode + key;
    console.log(key)
    console.log(alimentarQRCode)
    document.querySelector('#QRCodeImage').src = alimentarQRCode;
    document.querySelector('#code').value = key;
}