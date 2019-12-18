using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Configuration;

namespace controle.Business
{
    public class Factory
    {
        static MySqlConnection cn;
        static MySqlTransaction trans;





        public static MySqlConnection GetDataBase()
        {
            try
            {
                if (cn == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;

                    cn = new MySqlConnection(connectionString);
                    cn.Open();
                    //controle.Business.Factory.ExecuteNonQuery(CommandType.Text, "SET DATEFORMAT dmy;");
                }
                else
                    if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    //controle.Business.Factory.ExecuteNonQuery(CommandType.Text, "SET DATEFORMAT dmy;");
                }
                return cn;
            }
            catch
            {
                throw new Exception("ESTAMOS PASSANDO POR PROBLEMAS TÉCNICOS, NA CONEXÃO COM O BANCO DE DADOS, ENTRE EM CONTATO COM O SUPORTE...");
            }
        }

        public static void FecharBanco()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        public static MySqlTransaction GetTransaction()
        {
            trans = GetDataBase().BeginTransaction();
            return trans;
        }

        #region NonQuery

        public static void ExecuteNonQuery(MySqlCommand strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery.ToString());
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                strQuery.Connection = cn;
                strQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*  finally
              {
                  FecharBanco();
              }*/
        }

        //Classe para execução de comando
        public static void ExecuteNonQuery(CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = tipo;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*  finally
              {
                  FecharBanco();
              } */
        }





        //Classe para execução de comando
        public static void ExecuteNonQuery(MySqlTransaction trans, CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = tipo;
                cmd.Transaction = trans;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*    finally
                {
                    FecharBanco();
                }*/
        }



        /// <summary>
        /// Usado quando necessita passar um comando Sql e uma transação.
        /// Usado em procedures que precisam de transação.
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdSql"></param>
        public static void ExecuteNonQuery(MySqlTransaction trans, MySqlCommand cmdSql)
        {
            try
            {
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd = cmdSql;
                //cmd.CommandText = strQuery.ToString();
                //cmd.CommandType = tipo;
                cmd.Transaction = trans;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*    finally
                {
                    FecharBanco();
                }*/
        }


        #endregion

        #region ExecuteDataSet

        //Classe que retorna um objeto DataSet
        public static DataSet ExecuteDataSet(string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                /*  Declarado um dataadapter e um dataset
                    passar o comando para o da (SqlDataAdapter) e
                    carregar o dataset com resultado da busca */
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*    finally
                {
                    FecharBanco();
                }*/
        }

        //Classe que retorna um objeto DataSet
        public static DataSet ExecuteDataSet(CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = tipo;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                /*  Declarado um dataadapter e um dataset
                    passar o comando para o da (SqlDataAdapter) e
                    carregar o dataset com resultado da busca */
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*  finally
              {
                  FecharBanco();
              }*/
        }

        public static DataSet ExecuteDataSet(MySqlTransaction trans, CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = tipo;
                cmd.Transaction = trans;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                /*  Declarado um dataadapter e um dataset
                    passar o comando para o da (SqlDataAdapter) e
                    carregar o dataset com resultado da busca */
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*    finally
                {
                    FecharBanco();
                }*/
        }

        #endregion

        #region ExecuteScalar

        //Classe para retornar um DataReader()
        public static object ExecuteScalar(string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*   finally
               {
                   FecharBanco();
               }*/
        }

        //Classe para retornar um DataReader()
        public static object ExecuteScalar(CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = tipo;
                cmd.Connection = cn;
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /* finally
             {
                 FecharBanco();
             }*/
        }

        //Classe para retornar um DataReader()
        public static object ExecuteScalar(MySqlTransaction trans, CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = tipo;
                cmd.Transaction = trans;
                cmd.Connection = cn;
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*  finally
              {
                  FecharBanco();
              }*/
        }

        #endregion

        //Classe para execução de comando
        public static IDataReader ExecuteReader(CommandType tipo, string strQuery)
        {
            try
            {
                //if (SandBeach.FichaTecnica.Business.UsuarioFichaTecnica.viewSql)
                //{
                //frmViewSQL frm = new frmViewSQL(strQuery);
                //frm.ShowDialog();
                //}
                cn = GetDataBase();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = tipo;
                cmd.Connection = cn;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*  finally
              {
                  FecharBanco();
              } */
        }
    }
}
