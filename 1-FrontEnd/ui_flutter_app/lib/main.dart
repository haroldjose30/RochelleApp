import 'package:flutter/material.dart';

void main() {
  runApp(MaterialApp(
    title: 'Rochelle App',
    home: HomePage(),
  ));
}

class HomePage extends StatefulWidget {
  HomePage({Key key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  int _selectedIndex = 1;
  final _widgetOptions = [

    _HomeTab(),
    Text('Index 1: Business'),
    Text('Index 2: School'),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Rochelle App'),
      ),
      body: Center(
        child: _widgetOptions.elementAt(_selectedIndex),
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: <BottomNavigationBarItem>[
          BottomNavigationBarItem(icon: Icon(Icons.home), title: Text('Home')),
          BottomNavigationBarItem(icon: Icon(Icons.account_circle), title: Text('Login')),
          BottomNavigationBarItem(icon: Icon(Icons.business), title: Text('Site')),
        ],
        currentIndex: _selectedIndex,
        fixedColor: Colors.deepPurple,
        onTap: _onItemTapped,
      ),
    );
  }

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }



}

Widget _HomeTab() {
  return Column(
      children: <Widget>[
        Padding(
          padding: const EdgeInsets.fromLTRB(30,30,30,0),
          child: Image.asset(
            'assets/logo_empresa.png',
          ),
        ),
        Padding(
          padding: const EdgeInsets.fromLTRB(0,0,0,15),
          child: Text('SLOGAN DO APP',
            style: new TextStyle(
              fontSize: 30.0,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        Image.asset(
          'assets/banner_cartao.png',
        ),
        Padding(
          padding: const EdgeInsets.all(15),
          child: Text('Programa de Fidelidade e Recompensa',
            style: TextStyle(
              fontSize: 20.0,
              fontStyle: FontStyle.italic,
            ),
          ),
        ),
        FlatButton(
          child: const Text('+ mais informações +',
            style: TextStyle(
              fontSize: 20.0,
              color: Colors.blueAccent,
            ),

          ),
          onPressed: () {
            // Perform some action
          },
        ),
      ],
    );
}

