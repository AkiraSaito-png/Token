import 'package:flutter/material.dart';
import 'package:postgres/postgres.dart';
import 'package:sebsa/pages/signUp_page.dart';

Future<void> main() async {
  final conn = PostgreSQLConnection(
      'sebsa.covoattbbrhu.sa-east-1.rds.amazonaws.com', 
      5435, 
      'sebsa',
      username: 'postgres', 
      password: '12345678',
      );
      await conn.open();
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) => MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Sebsa',
      initialRoute: 'login',
      routes: {
        'login': (context) => LoginPage(),
      },
    );
}