select * from tb_empregos te
inner join tb_favoritos tf on(tf.idVaga = te.id)
where tf.idUser = 2

