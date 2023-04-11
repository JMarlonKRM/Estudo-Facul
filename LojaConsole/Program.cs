var contexto = new Contexto();
contexto.Restaurar();

var menu = new Menu(contexto);
menu.MenuPrincipal();

contexto.Salvar();
