import 'package:flutter/material.dart';
import 'package:sebsa/pages/validar_page.dart';
import 'package:sebsa/pages/signUp_page.dart';

Future<void> main() async {
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
        'validar_page': (context) => Validar_page(),
      },
    );
}