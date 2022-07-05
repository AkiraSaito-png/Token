function gerarQRCode() {
    const random = (max, min) => Math.floor(Math.random() * (max - min) + min);
    var QRCode = 'https://chart.googleapis.com/chart?cht=qr&chs=400x400&chld=H&chl=';
    var alimentarQRCode = QRCode + random(100000, 999999);
    console.log(alimentarQRCode)
    document.querySelector('#QRCodeImage').src = alimentarQRCode;
}