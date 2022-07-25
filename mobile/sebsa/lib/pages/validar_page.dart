import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_barcode_scanner/flutter_barcode_scanner.dart';

class Validar_page extends StatefulWidget {
  @override
  _Validar_page createState() => _Validar_page();
}

class _Validar_page extends State<Validar_page> {
  @override
  Widget build(BuildContext context) {
    return Container(
        alignment: Alignment.center,
        child: Flex(
            direction: Axis.vertical,
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              ElevatedButton(
                  onPressed: () => scanQR(), child: Text('Start QR scan')),
            ]));
  }

  Future<void> scanQR() async {
    String qrScanRes;
    try {
      qrScanRes = await FlutterBarcodeScanner.scanBarcode(
          '#ff6666', 'Cancel', true, ScanMode.QR);
      print(qrScanRes);
    } on PlatformException {
      qrScanRes = 'falha ao ler o código';
    }
  }
}
