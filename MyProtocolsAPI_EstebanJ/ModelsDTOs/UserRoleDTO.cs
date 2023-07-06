namespace MyProtocolsAPI_EstebanJ.ModelsDTOs
{
    public class UserRoleDTO
    {
        //Un DTO(data transfer object) sirve basicamente para dos funciones:
        //1. simplificar la estructura de los JSON  que se envian y llegan a los end ponits de los controllers,
        //quitando composiciones innecesarios que solo harian que los JSON  sean muy pesados o que muestren informacion
        //que no desea ver
        //2.Ocultar la estructura real de los modelos y por tanto de las tablas de bases de datos,a los programadores
        //de las apps, paginas web o aplicaciones de escritorio

        //tomando en cuenta el segundo criterio, y solo a manera de ejemplo, este DTO tendra los nombres de propiedades
        // en espanol



        public int IDRolUsuario { get; set; }
        public string DescripcionRol { get; set; } = null!;
    }
}
