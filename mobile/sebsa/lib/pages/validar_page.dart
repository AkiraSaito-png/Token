import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_barcode_scanner/flutter_barcode_scanner.dart';
import 'package:postgres/postgres.dart';
import 'package:sebsa/pages/signUp_page.dart';

class Validar_page extends StatefulWidget {
  @override
  _Validar_page createState() => _Validar_page();
}

class _Validar_page extends State<Validar_page> {
  String ticket = '';
  @override
  Widget build(BuildContext context) {
    return Container(
        alignment: Alignment.center,
        child: Flex(
            direction: Axis.vertical,
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              if(ticket != '')
                Padding(
                  padding: EdgeInsets.only(bottom: 24.0),
                  child: Text(
                    'Ticket: $ticket',
                    style: TextStyle(fontSize: 20),
                  ),
                ),
              ElevatedButton(
                  onPressed: scanQR, child: Text('Start QR scan')),
            ]));
  }

  scanQR() async {
      String qrScanRes = await FlutterBarcodeScanner.scanBarcode(
          '#ff6666', 'Cancel', true, ScanMode.QR);
      print(qrScanRes);
      setState(() => ticket = qrScanRes != '-1' ? qrScanRes : 'não validado');
      validar(2, ticket);
  }

  validar (id, code) async{
    final conn = PostgreSQLConnection(
      'sebsa.covoattbbrhu.sa-east-1.rds.amazonaws.com', 
      5432, 
      'sebsa',
      username: 'postgres', 
      password: '12345678',
      );
      await conn.open();

      var db = await conn.query("UPDATE code SET status = 'y' WHERE id_usuario = @id AND code = @code", substitutionValues: {
        'id': id,
        'code': code,
      });
      print(db);
  }
}
